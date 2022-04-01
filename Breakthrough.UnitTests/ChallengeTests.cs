using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Breakthrough;
using FluentAssertions;

namespace Breakthrough.UnitTests
{
    public class ChallengeTests
    {
        [Theory]
        [InlineData("Pb, Fa, Pc", "Pb")]
        [InlineData("Pb, Fa, Pc", "Fa, Pb")]
        [InlineData("Pb, Fa, Pc", "Kc, Pc, Pb")]
        private void IsPartiallyMet_ShouldReturnTrue_ForOnePartSolved(string conditions, string sequence)
        {
            // Arrange
            var actual = Challenge.IsPartiallySolved(conditions, sequence);
            // Assert
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData("Pb, Fa, Pc", "Pb, Fa")]
        [InlineData("Pb, Fa, Pc", "Fa, Pb, Fa")]
        [InlineData("Pb, Fa, Pc", "Kc, Pc, Pb, Fa")]
        private void IsPartiallyMet_ShouldReturnTrue_ForTwoPartsSolved(string conditions, string sequence)
        {
            // Arrange
            var actual = Challenge.IsPartiallySolved(conditions, sequence);
            // Assert
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData("Pb, Fa, Pc", "Pb")]
        [InlineData("Pb, Fa, Pc", "Fa, Pb, Fa")]
        [InlineData("Pb, Fa, Pc", "Kc, Pc, Pb, Fa")]
        [InlineData("Pb, Fa, Pc, Kc, Fa, Fc, Pc", "Kc, Pb, Fa, Pc, Kc, Fa")]
        private void IsPartiallyMet_ShouldReturnTrue_ForNPartsSolved(string conditions, string sequence)
        {
            // Arrange
            var actual = Challenge.IsPartiallySolved(conditions, sequence);
            // Assert
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData("Pb, Fa, Pc", "Pb, Fc")]
        [InlineData("Pb, Fa, Pc", "Fa, Pb, Fa, Kc")]
        [InlineData("Pb, Fa, Pc", "Kc, Pc, Pb, Fa, Kc")]
        [InlineData("Pb, Fa, Pc, Kc, Fa, Fc, Pc", "Kc, Pb, Fa, Pc, Kc, Fa, Kc")]
        private void IsPartiallyMet_ShouldReturnFalse_ForNotSolved(string conditions, string sequence)
        {
            // Arrange
            var actual = Challenge.IsPartiallySolved(conditions, sequence);
            // Assert
            actual.Should().BeFalse();
        }
    }
}
