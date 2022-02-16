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

        [Fact]
        public void NotNull_When_Reference_Is_Null_Throws_ArgumentNullException()
        {
            object? reference = null;

            Assert.Throws<ArgumentNullException>(nameof(reference), () => Check.NotNull(reference));
        }

        [Fact]
        public void NotNull_When_Reference_Is_Not_Null_Returns_Reference()
        {
            object? reference = new();

            Assert.Same(reference, Check.NotNull(reference));
        }

        [Fact]
        public void Reference_Is_Considered_Not_Null_After_Calling_CheckNotNull()
        {
            object? reference = new();
            Check.NotNull(reference);
            reference.ToString();
        }

        #endregion

        #region Check.NullableButNotEmpty

        [Fact]
        public void NullableButNotEmpty_When_Text_Is_Empty_Throws_ArgumentException()
        {
            string text = string.Empty;

            Assert.Throws<ArgumentException>(nameof(text), () => Check.NullableButNotEmpty(text));
        }

        [Fact]
        public void NullableButNotEmpty_When_Text_Is_Null_Returns_Null()
        {
            string? text = null;

            Assert.Null(Check.NullableButNotEmpty(text));
        }

        [Fact]
        public void NullableButNotEmpty_When_Text_Is_Not_Null_Returns_Text()
        {
            string text = "PSG";

            Assert.Same(text, Check.NullableButNotEmpty(text));
        }

        #endregion

        #region Check.NotNullOrEmpty : string

        [Fact]
        public void NotNullOrEmpty_When_Text_Is_Empty_Throws_ArgumentException()
        {
            string text = string.Empty;

            Assert.Throws<ArgumentException>(nameof(text), () => Check.NotNullOrEmpty(text));
        }

        [Fact]
        public void NotNullOrEmpty_When_Text_Is_Null_Throws_ArgumentNullException()
        {
            string? text = null;

            Assert.Throws<ArgumentNullException>(nameof(text), () => Check.NotNullOrEmpty(text));
        }

        [Fact]
        public void NotNullOrEmpty_When_Text_Is_Not_Null_Returns_Text()
        {
            string text = "PSG";

            Assert.Same(text, Check.NotNullOrEmpty(text));
        }

        [Fact]
        public void Text_Is_Considered_Not_Null_After_Calling_NotNullOrEmpty()
        {
            string? text = "PSG";
            Check.NotNullOrEmpty(text);
            text.ToString();
        }

        #endregion

        #region Check.NotNullOrEmpty

        [Fact]
        public void NotNullOrEmpty_When_Enumerable_Is_Null_Throws_ArgumentNullException()
        {
            IEnumerable<int>? enumerable = null;

            Assert.Throws<ArgumentNullException>(nameof(enumerable), () => Check.NotNullOrEmpty(enumerable));
        }

        [Fact]
        public void NotNullOrEmpty_When_Enumerable_Has_No_Element_Throws_ArgumentException()
        {
            var enumerable = new List<int>();

            Assert.Throws<ArgumentException>(nameof(enumerable), () => Check.NotNullOrEmpty(enumerable));
        }

        [Fact]
        public void NotNullOrEmpty_When_Enumerable_Is_Not_Empty_Returns_Enumerable()
        {
            var enumerable = new List<int> { 1, 2, 3 };

            Assert.Same(enumerable, Check.NotNullOrEmpty(enumerable));
        }

        [Fact]
        public void Enumerable_Is_Considered_Not_Null_After_Calling_NotNullOrEmpty()
        {
            IEnumerable<int>? enumerable = new List<int> { 1 };
            Check.NotNullOrEmpty(enumerable);
            enumerable.ToString();
        }

        #endregion

        #region Check.NotEmpty : GUID

        [Fact]
        public void NotEmpty_When_GUID_Is_Empty_Throws_ArgumentException()
        {
            Guid id = Guid.Empty;

            Assert.Throws<ArgumentException>(nameof(id), () => Check.NotEmpty(id));
        }

        [Fact]
        public void NotEmpty_When_GUID_Is_Not_Empty_Returns_GUID()
        {
            var id = Guid.NewGuid();

            Assert.Equal(id, Check.NotEmpty(id));
        }

        #endregion

        #region Check.HasNoNulls

        [Fact]
        public void HasNoNulls_When_Enumerable_Is_Null_Throws_ArgumentNullException()
        {
            IEnumerable<string>? enumerable = null;

            Assert.Throws<ArgumentNullException>(nameof(enumerable), () => Check.HasNoNulls(enumerable));
        }

        [Fact]
        public void HasNoNulls_When_Enumerable_Contains_One_Null_Throws_ArgumentException()
        {
            IEnumerable<string?> enumerable = new List<string?> { "1", null, "3" };

            Assert.Throws<ArgumentException>(nameof(enumerable), () => Check.HasNoNulls(enumerable));
        }

        [Fact]
        public void HasNoNulls_When_Enumerable_Contains_No_Null_Returns_Enumerable()
        {
            IEnumerable<string> enumerable = new List<string> { "1", "2", "3" };

            Assert.Same(enumerable, Check.HasNoNulls(enumerable));
        }

        [Fact]
        public void Enumerable_Is_Considered_Not_Null_After_Calling_HasNoNulls()
        {
            IEnumerable<string> enumerable = new List<string> { "1", "2", "3" };
            Check.HasNoNulls(enumerable);
            enumerable.ToString();
        }

        #endregion

        #region Check.FileExists

        [Fact]
        public void FileExists_When_File_Is_Null_Throws_ArgumentNullException()
        {
            string? file = null;

            Assert.Throws<ArgumentNullException>(nameof(file), () => Check.FileExists(file));
        }

        [Fact]
        public void FileExists_When_File_Does_Not_Exist_Throws_ArgumentException()
        {
            string file = @"C:\PSG.fr";

            Assert.Throws<ArgumentException>(nameof(file), () => Check.FileExists(file));
        }

        [Fact]
        public void FileExists_When_File_Exists_Returns_File()
        {
            string file = typeof(CheckTest).GetTypeInfo().Assembly.Location;

            Assert.Same(file, Check.FileExists(file));
        }

        [Fact]
        public void File_Is_Considered_Not_Null_After_Calling_FileExists()
        {
            string? file = typeof(CheckTest).GetTypeInfo().Assembly?.Location;
            Check.FileExists(file);
            file.ToString();
        }

        #endregion

        #region Check.DirectoryExists

        [Fact]
        public void DirectoryExists_When_Dir_Is_Null_Throws_ArgumentNullException()
        {
            string? dir = null;

            Assert.Throws<ArgumentNullException>(nameof(dir), () => Check.DirectoryExists(dir));
        }

        [Fact]
        public void DirectoryExists_When_Dir_Does_Not_Exist_Throws_ArgumentException()
        {
            string dir = @"C:\PSG";

            Assert.Throws<ArgumentException>(nameof(dir), () => Check.DirectoryExists(dir));
        }

        [Fact]
        public void DirectoryExists_When_Dir_Exists_Returns_Dir()
        {
            string? dir = Path.GetDirectoryName(typeof(CheckTest).GetTypeInfo().Assembly.Location);

            Assert.Same(dir, Check.DirectoryExists(dir));
        }

        [Fact]
        public void Dir_Is_Considered_Not_Null_After_Calling_DirectoryExists()
        {
            string? dir = Path.GetDirectoryName(typeof(CheckTest).GetTypeInfo().Assembly.Location);
            Check.DirectoryExists(dir);
            dir.ToString();
        }

        #endregion

        #region Check.Positive

        [Fact]
        public void Positive_When_Long_Is_Positive_Returns_Long()
        {
            long number = 1L;
            Assert.Equal(number, Check.Positive(number));
        }

        [Fact]
        public void Positive_When_Long_Is_Negative_Throws_ArgumentOutOfRangeException()
        {
            long number = 0L;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Positive(number));
        }

        #endregion

        #region Check.Positive?

        [Fact]
        public void Positive_When_Nullable_Double_Is_Positive_Returns_Double()
        {
            double? number = 1d;
            Assert.Equal(number, Check.Positive(number));
        }

        [Fact]
        public void Positive_When_Nullable_Double_Is_Null_Throws_ArgumentNullException()
        {
            double? number = null;
            Assert.Throws<ArgumentNullException>(nameof(number), () => Check.Positive(number));
        }

        [Fact]
        public void Positive_When_Nullable_Double_Is_Negative_Throws_ArgumentOutOfRangeException()
        {
            double? number = 0d;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Positive(number));
        }

        #endregion

        #region Check.PositiveOrNull

        [Fact]
        public void PositiveOrNull_When_Null_Returns_Null()
        {
            decimal? number = null;
            Assert.Null(Check.PositiveOrNull(number));
        }

        [Fact]
        public void PositiveOrNull_When_Decimal_Is_Positive_Returns_Decimal()
        {
            decimal? number = 1m;
            Assert.Equal(number, Check.PositiveOrNull(number));
        }

        [Fact]
        public void PositiveOrNull_When_Decimal_Is_Negative_Throws_ArgumentOutOfRangeException()
        {
            decimal? number = 0m;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.PositiveOrNull(number));
        }

        #endregion

        #region Check.Negative

        [Fact]
        public void Negative_When_Short_Is_Negative_Returns_Short()
        {
            short number = -1;
            Assert.Equal(number, Check.Negative(number));
        }

        [Fact]
        public void Negative_When_Short_Is_Zero_Throws_ArgumentOutOfRangeException()
        {
            short number = 0;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Negative(number));
        }

        #endregion

        #region Check.Negative?

        [Fact]
        public void Negative_When_Nullable_Float_Is_Negative_Returns_Float()
        {
            float? number = -1f;
            Assert.Equal(number, Check.Negative(number));
        }

        [Fact]
        public void Negative_When_Nullable_Float_Is_Null_Throws_ArgumentNullException()
        {
            float? number = null;
            Assert.Throws<ArgumentNullException>(nameof(number), () => Check.Negative(number));
        }

        [Fact]
        public void Negative_When_Nullable_Float_Is_Positive_Throws_ArgumentOutOfRangeException()
        {
            float? number = 1f;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.Negative(number));
        }

        #endregion

        #region Check.NegativeOrNull

        [Fact]
        public void NegativeOrNull_When_Null_Returns_Null()
        {
            sbyte? number = null;
            Assert.Null(Check.NegativeOrNull(number));
        }

        [Fact]
        public void NegativeOrNull_When_SByte_Is_Negative_Returns_SByte()
        {
            sbyte? number = -1;
            Assert.Equal(number, Check.NegativeOrNull(number));
        }

        [Fact]
        public void NegativeOrNull_When_SByte_Is_Positive_Throws_ArgumentOutOfRangeException()
        {
            sbyte? number = 1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.NegativeOrNull(number));
        }

        #endregion

        #region Check.NotNegative

        [Fact]
        public void NotNegative_When_Int_Is_NotNegative_Returns_Int()
        {
            int number = 0;
            Assert.Equal(number, Check.NotNegative(number));
        }

        [Fact]
        public void NotNegative_When_Int_Is_Negative_Throws_ArgumentOutOfRangeException()
        {
            long number = -1L;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.NotNegative(number));
        }

        #endregion

        #region Check.NotNegative?

        [Fact]
        public void NotNegative_When_Nullable_Int_Is_Zero_Returns_Int()
        {
            int? number = 0;
            Assert.Equal(number, Check.NotNegative(number));
        }

        [Fact]
        public void NotNegative_When_Nullable_Int_Is_Null_Throws_ArgumentNullException()
        {
            int? number = null;
            Assert.Throws<ArgumentNullException>(nameof(number), () => Check.NotNegative(number));
        }

        [Fact]
        public void NotNegative_When_Nullable_Int_Is_Negative_Throws_ArgumentOutOfRangeException()
        {
            int? number = -1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.NotNegative(number));
        }

        #endregion

        #region Check.NotNegativeOrNull

        [Fact]
        public void NotNegativeOrNull_When_Null_Returns_Null()
        {
            int? number = null;
            Assert.Null(Check.NotNegativeOrNull(number));
        }

        [Fact]
        public void NotNegativeOrNull_When_Int_Is_Positive_Returns_Int()
        {
            int? number = 1;
            Assert.Equal(number, Check.NotNegativeOrNull(number));
        }

        [Fact]
        public void NotNegativeOrNull_When_Int_Is_Negative_Throws_ArgumentOutOfRangeException()
        {
            int? number = -1;
            Assert.Throws<ArgumentOutOfRangeException>(nameof(number), () => Check.NotNegativeOrNull(number));
        }

        #endregion

        #region Check.Condition

        [Fact]
        public void True_When_Predicate_Is_Null_Throws_ArgumentNullException()
        {
            Func<bool>? condition = null;

            Assert.Throws<ArgumentNullException>(nameof(condition), () => Check.True(condition));
        }

        [Fact]
        public void True_When_Predicate_Returns_False_Throws_ArgumentException()
        {
            Func<bool>? condition = () => false;

            Assert.Throws<ArgumentException>(nameof(condition), () => Check.True(condition));
        }

        [Fact]
        public void True_When_Predicate_Returns_True_Returns()
        {
            Func<bool>? condition = () => true;

            Check.True(condition);
        }

        [Fact]
        public void True_When_Predicate_Returns_True_Returns_Value()
        {
            Func<bool>? condition = () => true;

            Assert.Same("OK", Check.True(condition, returnValue: "OK"));
        }

        #endregion
    }
}