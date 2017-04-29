using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace Preconditions.Tests
{
    public class CheckTest
    {
        #region Check.NotNull

        [Fact(DisplayName = "When the ref is null throws ArgumentNullException")]
        public void When_reference_is_null_Throws_ArgumentNullException()
        {
            object reference = null;

            Assert.Throws<ArgumentNullException>(nameof(reference), () => Check.NotNull(reference, nameof(reference)));
        }

        [Fact(DisplayName = "When the ref is not null returns the ref")]
        public void When_reference_is_not_null_Returns_reference()
        {
            object reference = new object();

            Assert.Same(reference, Check.NotNull(reference, nameof(reference)));
        }

        #endregion

        #region Check.NotEmpty : ICollection

        [Fact(DisplayName = "When the collection is null throws ArgumentNullException")]
        public void When_collection_is_null_Throws_ArgumentNullException()
        {
            ICollection<int> collection = null;

            Assert.Throws<ArgumentNullException>(nameof(collection), () => Check.NotEmpty(collection, nameof(collection)));
        }

        [Fact(DisplayName = "When the collection has no element throws ArgumentException")]
        public void When_collection_has_no_element_Throws_ArgumentException()
        {
            ICollection<int> collection = new List<int>();

            Assert.Throws<ArgumentException>(nameof(collection), () => Check.NotEmpty(collection, nameof(collection)));
        }

        [Fact(DisplayName = "When the collection is not empty returns the collection")]
        public void When_collection_is_not_empty_Returns_collection()
        {
            ICollection<int> collection = new List<int> { 1, 2, 3};

            Assert.Same(collection, Check.NotEmpty(collection, nameof(collection)));
        }

        #endregion

        #region Check.NotEmpty : IEnumerable

        [Fact(DisplayName = "When the enumerable is null throws ArgumentNullException")]
        public void When_enumerable_is_null_Throws_ArgumentNullException()
        {
            IEnumerable<int> enumerable = null;

            Assert.Throws<ArgumentNullException>(nameof(enumerable), () => Check.NotEmpty(enumerable, nameof(enumerable)));
        }

        [Fact(DisplayName = "When the enumerable has no element throws ArgumentException")]
        public void When_enumerable_has_no_element_Throws_ArgumentException()
        {
            IEnumerable<int> enumerable = new List<int>();

            Assert.Throws<ArgumentException>(nameof(enumerable), () => Check.NotEmpty(enumerable, nameof(enumerable)));
        }

        [Fact(DisplayName = "When the enumerable is not empty returns the enumerable")]
        public void When_enumerable_is_not_empty_Returns_enumerable()
        {
            IEnumerable<int> enumerable = new List<int> { 1, 2, 3 };

            Assert.Same(enumerable, Check.NotEmpty(enumerable, nameof(enumerable)));
        }

        #endregion

        #region Check.HasNoNulls

        [Fact(DisplayName = "When the enumerable 2 is null throws ArgumentNullException")]
        public void When_enumerable2_is_null_Throws_ArgumentNullException()
        {
            IEnumerable<string> enumerable = null;

            Assert.Throws<ArgumentNullException>(nameof(enumerable), () => Check.HasNoNulls(enumerable, nameof(enumerable)));
        }

        [Fact(DisplayName = "When the enumerable contains at least one null element throws ArgumentException")]
        public void When_enumerable_contains_one_element_Throws_ArgumentException()
        {
            IEnumerable<string> enumerable = new List<string> { "1", null, "3" };

            Assert.Throws<ArgumentException>(nameof(enumerable), () => Check.HasNoNulls(enumerable, nameof(enumerable)));
        }

        [Fact(DisplayName = "When the enumerable does not contain any null element returns the enumerable")]
        public void When_enumerable_contains_no_null_element_Returns_enumerable()
        {
            IEnumerable<string> enumerable = new List<string> { "1", "2", "3" };

            Assert.Same(enumerable, Check.HasNoNulls(enumerable, nameof(enumerable)));
        }

        #endregion

        #region NullableButNotEmpty

        [Fact(DisplayName = "When the string is empty throws ArgumentException")]
        public void When_string_is_empty_Throws_ArgumentException()
        {
            string text = string.Empty;

            Assert.Throws<ArgumentException>(nameof(text), () => Check.NullableButNotEmpty(text, nameof(text)));
        }

        [Fact(DisplayName = "When the string is null returns null")]
        public void When_string_is_null_Returns_null()
        {
            string text = null;

            Assert.Same(text, Check.NullableButNotEmpty(text, nameof(text)));
        }

        [Fact(DisplayName = "When the string is not null returns the string")]
        public void When_string_is_not_null_Returns_string()
        {
            string text = "PSG";

            Assert.Same(text, Check.NullableButNotEmpty(text, nameof(text)));
        }

        #endregion

        #region NotNullOrEmpty

        [Fact(DisplayName = "When the string 2 is empty throws ArgumentException")]
        public void When_string_2_is_empty_Throws_ArgumentException()
        {
            string text = string.Empty;

            Assert.Throws<ArgumentException>(nameof(text), () => Check.NotNullOrEmpty(text, nameof(text)));
        }

        [Fact(DisplayName = "When the string is null throws ArgumentNullException")]
        public void When_string_is_null_Throws_ArgumentNullException()
        {
            string text = null;

            Assert.Throws<ArgumentNullException>(nameof(text), () => Check.NotNullOrEmpty(text, nameof(text)));
        }

        [Fact(DisplayName = "When the string 2 is not null returns the string")]
        public void When_string_2_is_not_null_Returns_string()
        {
            string text = "PSG";

            Assert.Same(text, Check.NotNullOrEmpty(text, nameof(text)));
        }

        #endregion

        #region FileExists

        [Fact(DisplayName = "When file is null throws ArgumentNullException")]
        public void When_file_is_null_Throws_ArgumentNullException()
        {
            string file = null;

            Assert.Throws<ArgumentNullException>(nameof(file), () => Check.FileExists(file, nameof(file)));
        }

        [Fact(DisplayName = "When file does not exist throws ArgumentException")]
        public void When_file_does_not_exist_Throws_ArgumentException()
        {
            string file = @"C:\PSG.fr";

            Assert.Throws<ArgumentException>(nameof(file), () => Check.FileExists(file, nameof(file)));
        }

        [Fact(DisplayName = "When file exists returns the file")]
        public void When_file_exists_Returns_file()
        {
            string file = typeof(CheckTest).GetTypeInfo().Assembly.Location;

            Assert.Same(file, Check.NotNullOrEmpty(file, nameof(file)));
        }

        #endregion

        #region DirectoryExists

        [Fact(DisplayName = "When directory is null throws ArgumentNullException")]
        public void When_directory_is_null_Throws_ArgumentNullException()
        {
            string dir = null;

            Assert.Throws<ArgumentNullException>(nameof(dir), () => Check.DirectoryExists(dir, nameof(dir)));
        }

        [Fact(DisplayName = "When directory does not exist throws ArgumentException")]
        public void When_directory_does_not_exist_Throws_ArgumentException()
        {
            string dir = @"C:\PSG\";

            Assert.Throws<ArgumentException>(nameof(dir), () => Check.DirectoryExists(dir, nameof(dir)));
        }

        [Fact(DisplayName = "When directory exists returns the directory")]
        public void When_directory_exists_Returns_directory()
        {
            string dir = Path.GetDirectoryName(typeof(CheckTest).GetTypeInfo().Assembly.Location);

            Assert.Same(dir, Check.NotNullOrEmpty(dir, nameof(dir)));
        }

        #endregion
    }
}
