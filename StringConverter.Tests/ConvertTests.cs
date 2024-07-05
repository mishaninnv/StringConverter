using StringConverter.Exceptions;

namespace StringConverter.Tests;

public class ConvertTests
{
    [Fact]
    public void RemoveExtraSpaces_SuccessWithoutChanges()
    {
        // arrange
        var inputStrings1 = "abc";
        var inputString2 = "a b";
        var inputString3 = "a b c";

        // act
        var convertString1 = inputStrings1.RemoveExtraSpaces();
        var convertString2 = inputString2.RemoveExtraSpaces();
        var convertString3 = inputString3.RemoveExtraSpaces();

        // assert
        Assert.Equal(convertString1, inputStrings1);
        Assert.Equal(convertString2, inputString2);
        Assert.Equal(convertString3, inputString3);
    }

    [Fact]
    public void RemoveExtraSpaces_SuccessWithChanges()
    {
        // arrange
        var inputString1 = new[] { "a  b", "a b" };
        var inputString2 = new[] { "a   b", "a b" };
        var inputString3 = new[] { "a  b  c", "a b c" };
        var inputString4 = new[] { "a   b   c", "a b c" };

        // act
        var convertString1 = inputString1[0].RemoveExtraSpaces();
        var convertString2 = inputString2[0].RemoveExtraSpaces();
        var convertString3 = inputString3[0].RemoveExtraSpaces();
        var convertString4 = inputString4[0].RemoveExtraSpaces();

        // assert
        Assert.Equal(convertString1, inputString1[1]);
        Assert.Equal(convertString2, inputString2[1]);
        Assert.Equal(convertString3, inputString3[1]);
        Assert.Equal(convertString4, inputString4[1]);
    }

    [Fact]
    public void RemoveExtraSpaces_SuccessWithChangesSpecSymbols()
    {
        // arrange
        var inputString1 = new[] { "a&nbsp;b", "a b" };
        var inputString2 = new[] { "a \u00a0b", "a b" };
        var inputString3 = new[] { "a \u00a0\t\r\nb", "a b" };
        var inputString4 = new[] { "a &nbsp;b", "a b" };

        // act
        var convertString1 = inputString1[0].RemoveExtraSpaces();
        var convertString2 = inputString2[0].RemoveExtraSpaces();
        var convertString3 = inputString3[0].RemoveExtraSpaces();
        var convertString4 = inputString4[0].RemoveExtraSpaces();

        // assert
        Assert.Equal(convertString1, inputString1[1]);
        Assert.Equal(convertString2, inputString2[1]);
        Assert.Equal(convertString3, inputString3[1]);
        Assert.Equal(convertString4, inputString4[1]);
    }

    [Fact]
    public void RemoveExtraSpaces_FailEmptyString()
    {
        // arrange
        var inputString = "";

        // act

        // assert
        Assert.Throws<EmptyStringException>(() => inputString.RemoveExtraSpaces());
    }
}
