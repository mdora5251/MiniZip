﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Knapcode.MiniZip
{
    public class VirtualOffsetStreamTest
    {
        public class ReadAsync : Facts
        {
            [Theory]
            [MemberData(nameof(AllowsReadingOfZipCentralDirectoryData))]
            public async Task AllowsReadingOfZipCentralDirectory(string path)
            {
                // Arrange
                var originalStream = TestUtility.BufferTestData(path);
                var result = await TestUtility.ReadWithMiniZipAsync(originalStream);

                var expected = result.Data;
                var innerStream = new MemoryStream();

                var virtualOffset = (long)(expected.Zip64?.OffsetOfCentralDirectory ?? expected.OffsetOfCentralDirectory);
                originalStream.Position = virtualOffset;

                await originalStream.CopyToAsync(innerStream);
                var target = new VirtualOffsetStream(innerStream, virtualOffset);
                var reader = new ZipDirectoryReader(target);
                var expectedSize = originalStream.Length - virtualOffset;

                // Act
                var actual = await reader.ReadAsync();

                // Assert
                TestUtility.VerifyJsonEquals(expected, actual);
                Assert.Equal(expectedSize, innerStream.Length);
                Assert.Equal(originalStream.Length, target.Length);
            }

            public static IEnumerable<object[]> AllowsReadingOfZipCentralDirectoryData => TestUtility
                .ValidTestDataPaths
                .Select(x => new object[] { x });
        }

        public class Read : Facts
        {
            [Fact]
            public void ReadInnerStreamAllAtOnce()
            {
                // Arrange
                var destination = new byte[_bytes.Length * 2];
                var expectedRead = _bytes.Length;
                _target.Position = _virtualOffset;

                // Act
                var read = _target.Read(destination, 0, destination.Length);

                // Assert
                Verify(0, _bytes.Length, destination, _bytes.Length);
                Assert.Equal(expectedRead, read);
            }

            [Fact]
            public void ReadInnerStreamByteByByte()
            {
                // Arrange
                var destination = new byte[_bytes.Length * 2];
                var expectedRead = _bytes.Length;
                _target.Position = _virtualOffset;

                // Act
                var read = 0;
                for (var offset = 0; offset < destination.Length; offset++)
                {
                    read += _target.Read(destination, offset, 1);
                }

                // Assert
                Verify(0, _bytes.Length, destination, _bytes.Length);
                Assert.Equal(expectedRead, read);
            }

            [Fact]
            public void ReadInnerStreamByteByByteInReverse()
            {
                // Arrange
                var destination = new byte[_bytes.Length * 2];
                var expectedRead = _bytes.Length;
                _target.Position = _target.Length - 1;

                // Act
                var read = 0;
                for (var offset = _bytes.Length - 1; offset >= 0; offset--)
                {
                    read += _target.Read(destination, offset, 1);
                    _target.Position -= 2;
                }

                // Assert
                Verify(0, _bytes.Length, destination, _bytes.Length);
                Assert.Equal(expectedRead, read);
            }

            [Fact]
            public void AllowsIntermediatePosition()
            {
                // Arrange
                var destination = new byte[_bytes.Length];
                var expectedRead = _bytes.Length - 5;
                _target.Position = _virtualOffset + 5;

                // Act
                var read = _target.Read(destination, 0, destination.Length);

                // Assert
                Verify(5, _bytes.Length, destination, _bytes.Length - 5);
                Assert.Equal(expectedRead, read);
            }

            [Fact]
            public void AllowsPartialRead()
            {
                // Arrange
                var destination = new byte[5];
                var expectedRead = 3;
                _target.Position = _virtualOffset + 1;

                // Act
                var read = _target.Read(destination, 0, expectedRead);

                // Assert
                Verify(1, 4, destination, 2);
                Assert.Equal(expectedRead, read);
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            public void ReadsNothingIfPositionIsAfterEnd(int delta)
            {
                // Arrange
                var destination = new byte[2];
                var expectedRead = 0;
                _target.Position = _virtualOffset + _bytes.Length + delta;

                // Act
                var read = _target.Read(destination, 0, expectedRead);

                // Assert
                Verify(0, 0, destination, 2);
                Assert.Equal(expectedRead, read);
            }
        }

        public class Position : Facts
        {
            [Fact]
            public void AllowsSettingPositionToLessThanVirtualOffset()
            {
                // Arrange & Act
                _target.Position = _virtualOffset - 1;

                // Assert
                Assert.Equal(_virtualOffset - 1, _target.Position);
            }
        }

        public class Length : Facts
        {
            [Fact]
            public void IsVirtualOffsetPlusInnerLength()
            {
                Assert.Equal(_virtualOffset + _bytes.Length, _target.Length);
            }
        }

        public class Facts
        {
            protected byte[] _bytes;
            protected MemoryStream _innerStream;
            protected long _virtualOffset;
            internal VirtualOffsetStream _target;

            public Facts()
            {
                _bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                _innerStream = new MemoryStream(_bytes);
                _virtualOffset = 20;
                _target = new VirtualOffsetStream(_innerStream, _virtualOffset);
            }

            protected void Verify(int start, int end, byte[] actual, int extraBytes)
            {
                var count = end - start;
                var expected = new byte[count + extraBytes];
                Buffer.BlockCopy(_bytes, start, expected, 0, count);
                Assert.Equal(expected, actual);
            }
        }
    }
}
