﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;

namespace Flexor.Tests
{
    [TestClass]
    public class FluentSizeShould
    {
        private ISize underTest;

        [TestMethod]
        public void Constructor_Default_Null()
        {
            // Arrange
            this.underTest = new FluentSize();

            // Act
            var underTestClass = underTest.Class;

            // Assert
            underTestClass.Should().BeNullOrWhiteSpace();
        }

        [TestMethod]
        public void GetClass_IsPixels_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixelsOnAll(50);

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(5)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(5);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            underTestCss.Values.Should()
                .Match(values => values.All(value => Regex.Matches(value, "50px;").Count == 2));
        }

        [TestMethod]
        public void GetClass_IsPercent_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPercentOnAll(50);

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(5)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(5);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            underTestCss.Values.Should()
                .Match(values => values.All(value => Regex.Matches(value, "50%;").Count == 2));
        }

        [TestMethod]
        public void GetClass_IsElement_Correctly()
        {
            // Arrange
            this.underTest = Size.IsElementOnAll(50);

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(5)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(5);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            underTestCss.Values.Should()
                .Match(values => values.All(value => Regex.Matches(value, "50em;").Count == 2));
        }

        [TestMethod]
        public void GetClass_IsViewportHeight_Correctly()
        {
            // Arrange
            this.underTest = Size.IsViewportHeightOnAll(50);

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(5)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(5);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            underTestCss.Values.Should()
                .Match(values => values.All(value => Regex.Matches(value, "50vh;").Count == 2));
        }

        [TestMethod]
        public void GetClass_IsViewportWidth_Correctly()
        {
            // Arrange
            this.underTest = Size.IsViewportWidthOnAll(50);

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(5)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(5);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            underTestCss.Values.Should()
                .Match(values => values.All(value => Regex.Matches(value, "50vw;").Count == 2));
        }

        [TestMethod]
        public void OnMobile_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnMobile();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(1)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(1);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();
            
            lines.Should().HaveCount(1);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnMobileAndLarger_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnMobileAndLarger();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(5)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(5);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(5);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[1].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[2].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[3].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[4].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnTablet_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnTablet();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(1)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(1);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(1);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnTabletAndLarger_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnTabletAndLarger();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(4)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                 .NotBeNull()
                 .And
                 .HaveCount(4);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(4);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[1].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[2].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[3].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnTabletAndSmaller_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnTabletAndSmaller();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(2)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(2);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(2);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[1].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnDesktop_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnDesktop();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(1)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(1);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(1);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnDesktopAndLarger_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnDesktopAndLarger();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(3)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(3);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(3);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[1].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[2].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnDesktopAndSmaller_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnDesktopAndSmaller();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(3)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(3);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(3);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[1].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[2].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnWidescreen_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnWidescreen();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(1)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(1);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(1);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnWidescreenAndLarger_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnWidescreenAndLarger();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(2)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(2);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(2);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[1].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnWidescreenAndSmaller_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnWidescreenAndSmaller();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(4)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(4);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(4);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[1].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[2].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[3].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        [TestMethod]
        public void OnFullHD_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnFullHD();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();
            underTestClass.Split(' ').Should()
                .HaveCount(1)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(1);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(1);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }

        

        [TestMethod]
        public void OnFullHDAndSmaller_SetsValue_Correctly()
        {
            // Arrange
            this.underTest = Size.IsPixels(75).OnFullHDAndSmaller();

            // Act
            var underTestClass = underTest.Class;
            var underTestCss = underTest.Css;

            // Assert
            underTestClass.Should().NotBeNullOrWhiteSpace();

            underTestClass.Split(' ').Should()
                .HaveCount(5)
                .And
                .OnlyHaveUniqueItems();

            underTestCss.Should()
                .NotBeNull()
                .And
                .HaveCount(5);

            underTestCss.Keys.Should()
                .Match(keys => keys.All(key => !string.IsNullOrWhiteSpace(key)));


            var lines = underTestCss.Values.ToArray();

            lines.Should().HaveCount(5);

            lines[0].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[1].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[2].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[3].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
            lines[4].Should().Match(line => Regex.Matches(line, "75px;").Count == 2);
        }
    }
}
