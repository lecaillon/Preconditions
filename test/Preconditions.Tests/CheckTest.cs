using System;
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
    }
}
