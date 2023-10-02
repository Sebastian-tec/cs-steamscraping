using System.Xml;

namespace cssteamscraping;

internal static class Helper
{
    private static readonly string ErrorGroupInfo = "There was an error retrieving information about the specified group.";
    private static readonly string ErrorUrl = "No group could be retrieved for the given URL.";
    private static readonly string ErrorRemoved = "This group has been removed for violating the <a href=\"https://support.steampowered.com/kb_article.php?ref=4045-USHJ-3810\">Steam Community Rules and Guidelines</a>.";
    private static string[] unicodes = {
        "\u00AD", // Soft Hyphen

        "\u034F", // Combining Grapheme Joiner

        "\u0605", // Arabic Number Mark Above
        "\u061C", // Arabic Letter Mark

        "\u180C", // Mongolian Free Variation Selector Two
        "\u180E", // Mongolian Vowel Separator

        // "\u2000",
        // "\u2001",
        // "\u2002",
        // "\u2003",
        // "\u2004",
        // "\u2005",
        // "\u2006",
        // "\u2007",
        // "\u2008",
        // "\u2009",

        "\u200B", // Zero Width Space
        "\u200C", // Zero Width Non-Joiner
        "\u200D", // Zero Width Joiner
        "\u200E", // Left-To-Right Mark
        "\u200F", // Right-To-Left Mark

        "\u202A", // Left-To-Right Embedding
        "\u202B", // Right-To-Left Embedding
        "\u202C", // Pop Directional Formatting
        "\u202D", // Left-To-Right Override
        "\u202E", // Right-To-Left Override

        "\u2060", // Word Joiner
        "\u2061", // Function Application
        "\u2062", // Invisible Times
        "\u2063", // Invisible Separator
        "\u2064", // Invisible Plus
                  // "\u2065",
        "\u2066", // Left-To-Right Isolate
        "\u2067", // Right-To-Left Isolate
        "\u2068", // First Strong Isolate
        "\u2069", // Pop Directional Isolate

        "\u206A", // Inhibit Symmetric Swapping
        "\u206B", // Activate Symmetric Swapping
        "\u206C", // Inhibit Arabic Form Shaping
        "\u206D", // Activate Arabic Form Shaping
        "\u206E", // National Digit Shapes
        "\u206F", // Nominal Digit Shapes

        "\u3000", // Ideographic Space

        "\uFEFF", // Zero Width No-Break Space

        "\uFFF9", // Interlinear Annotation Anchor
        "\uFFFA", // Interlinear Annotation Separator
        "\uFFFB", // Interlinear Annotation Terminator

        "\uD834\uDD73", // Musical Symbol Begin Beam
        "\uD834\uDD74", // Musical Symbol End Beam
        "\uD834\uDD75", // Musical Symbol Begin Tie
        "\uD834\uDD76", // Musical Symbol End Tie
        "\uD834\uDD77", // Musical Symbol Begin Slur
        "\uD834\uDD78", // Musical Symbol End Slur
        "\uD834\uDD79", // Musical Symbol Begin Phrase
        "\uD834\uDD7A", // Musical Symbol End Phrase

        "\uDB40\uDC01", // Language Tag
        "\uDB40\uDC20", // Tag Space
        "\uDB40\uDC21", // Tag Exclamation Mark
        "\uDB40\uDC22", // Tag Quotation Mark
        "\uDB40\uDC23", // Tag Number Sign
        "\uDB40\uDC24", // Tag Dollar Sign
        "\uDB40\uDC25", // Tag Percent Sign
        "\uDB40\uDC26", // Tag Ampersand
        "\uDB40\uDC27", // Tag Apostrophe
        "\uDB40\uDC28", // Tag Left Parenthesis
        "\uDB40\uDC29", // Tag Right Parenthesis
        "\uDB40\uDC2A", // Tag Asterisk
        "\uDB40\uDC2B", // Tag Plus Sign
        "\uDB40\uDC2C", // Tag Comma
        "\uDB40\uDC2D", // Tag Hyphen
        "\uDB40\uDC2E", // Tag Full Stop
        "\uDB40\uDC2F", // Tag Solidus
        "\uDB40\uDC30", // Tag Digit Zero
        "\uDB40\uDC31", // Tag Digit One
        "\uDB40\uDC32", // Tag Digit Two
        "\uDB40\uDC33", // Tag Digit Three
        "\uDB40\uDC34", // Tag Digit Four
        "\uDB40\uDC35", // Tag Digit Five
        "\uDB40\uDC36", // Tag Digit Six
        "\uDB40\uDC37", // Tag Digit Seven
        "\uDB40\uDC38", // Tag Digit Eight
        "\uDB40\uDC39", // Tag Digit Nine
        "\uDB40\uDC3A", // Tag Colon
        "\uDB40\uDC3B", // Tag Semicolon
        "\uDB40\uDC3C", // Tag Less
        "\uDB40\uDC3D", // Tag Equals Sign
        "\uDB40\uDC3E", // Tag Greater
        "\uDB40\uDC3F", // Tag Question Mark
        "\uDB40\uDC40", // Tag Commercial At
        "\uDB40\uDC41", // Tag Latin Capital Letter A
        "\uDB40\uDC42", // Tag Latin Capital Letter B
        "\uDB40\uDC43", // Tag Latin Capital Letter C
        "\uDB40\uDC44", // Tag Latin Capital Letter D
        "\uDB40\uDC45", // Tag Latin Capital Letter E
        "\uDB40\uDC46", // Tag Latin Capital Letter F
        "\uDB40\uDC47", // Tag Latin Capital Letter G
        "\uDB40\uDC48", // Tag Latin Capital Letter H
        "\uDB40\uDC49", // Tag Latin Capital Letter I
        "\uDB40\uDC4A", // Tag Latin Capital Letter J
        "\uDB40\uDC4B", // Tag Latin Capital Letter K
        "\uDB40\uDC4C", // Tag Latin Capital Letter L
        "\uDB40\uDC4D", // Tag Latin Capital Letter M
        "\uDB40\uDC4E", // Tag Latin Capital Letter N
        "\uDB40\uDC4F", // Tag Latin Capital Letter O
        "\uDB40\uDC50", // Tag Latin Capital Letter P
        "\uDB40\uDC51", // Tag Latin Capital Letter Q
        "\uDB40\uDC52", // Tag Latin Capital Letter R
        "\uDB40\uDC53", // Tag Latin Capital Letter S
        "\uDB40\uDC54", // Tag Latin Capital Letter T
        "\uDB40\uDC55", // Tag Latin Capital Letter U
        "\uDB40\uDC56", // Tag Latin Capital Letter V
        "\uDB40\uDC57", // Tag Latin Capital Letter W
        "\uDB40\uDC58", // Tag Latin Capital Letter X
        "\uDB40\uDC59", // Tag Latin Capital Letter Y
        "\uDB40\uDC5A", // Tag Latin Capital Letter Z
        "\uDB40\uDC5B", // Tag Left Square Bracket
        "\uDB40\uDC5C", // Tag Reverse Solidus
        "\uDB40\uDC5D", // Tag Right Square Bracket
        "\uDB40\uDC5E", // Tag Circumflex Accent
        "\uDB40\uDC5F", // Tag Low Line
        "\uDB40\uDC60", // Tag Grave Accent
        "\uDB40\uDC61", // Tag Latin Small Letter A
        "\uDB40\uDC62", // Tag Latin Small Letter B
        "\uDB40\uDC63", // Tag Latin Small Letter C
        "\uDB40\uDC64", // Tag Latin Small Letter D
        "\uDB40\uDC65", // Tag Latin Small Letter E
        "\uDB40\uDC66", // Tag Latin Small Letter F
        "\uDB40\uDC67", // Tag Latin Small Letter G
        "\uDB40\uDC68", // Tag Latin Small Letter H
        "\uDB40\uDC69", // Tag Latin Small Letter I
        "\uDB40\uDC6A", // Tag Latin Small Letter J
        "\uDB40\uDC6B", // Tag Latin Small Letter K
        "\uDB40\uDC6C", // Tag Latin Small Letter L
        "\uDB40\uDC6D", // Tag Latin Small Letter M
        "\uDB40\uDC6E", // Tag Latin Small Letter N
        "\uDB40\uDC6F", // Tag Latin Small Letter O
        "\uDB40\uDC70", // Tag Latin Small Letter P
        "\uDB40\uDC71", // Tag Latin Small Letter Q
        "\uDB40\uDC72", // Tag Latin Small Letter R
        "\uDB40\uDC73", // Tag Latin Small Letter S	
        "\uDB40\uDC74", // Tag Latin Small Letter T
        "\uDB40\uDC75", // Tag Latin Small Letter U
        "\uDB40\uDC76", // Tag Latin Small Letter V
        "\uDB40\uDC77", // Tag Latin Small Letter W
        "\uDB40\uDC78", // Tag Latin Small Letter X
        "\uDB40\uDC79", // Tag Latin Small Letter Y
        "\uDB40\uDC7A", // Tag Latin Small Letter Z
        "\uDB40\uDC7B", // Tag Left Curly Bracket
        "\uDB40\uDC7C", // Tag Vertical Line
        "\uDB40\uDC7D", // Tag Right Curly Bracket
        "\uDB40\uDC7E", // Tag Tilde
        "\uDB40\uDC7F", // Cancel Tag
        "\uDB40\uDDD8" // Variation Selector-233
    };


    public static bool ContainsUnicode(string text) => unicodes.Any(text.Contains);

    public static string ReplaceUnicode(string text) => unicodes.Aggregate(text, (current, unicode) => current.Replace(unicode, "<p>!</p>"));

    public static string RemoveExclamationmarj(string text) => text.Replace("<p>!</p>", "");

    public static bool IsValidUrl(string url) => !string.IsNullOrEmpty(url) && !string.IsNullOrWhiteSpace(url);

    public static bool IsValidGid(int gid) => gid > 5 && gid != null;


    public static bool IsRemoved(XmlDocument xml) => xml.InnerText.Contains(ErrorRemoved);
    public static bool IsNotFound(XmlDocument xml) => xml.InnerText.Contains(ErrorUrl);
    public static bool IsError(XmlDocument xml) => xml.InnerText.Contains(ErrorGroupInfo);
    public static bool IsValidPage(XmlDocument xml) => !IsRemoved(xml) && !IsNotFound(xml) && !IsError(xml);

    public static bool HasYear(string date) => date.Contains("20");
    public static string AddYear(string date) => !HasYear(date) ? date + DateTime.Now.Year : date;

}

internal static class PageInfo
{
    public static string GetXmlGroupName(XmlDocument doc) => doc.SelectSingleNode("//groupName").InnerText;
    public static string GetXmlGroupUrl(XmlDocument doc) => doc.SelectSingleNode("//groupURL").InnerText;
    public static string GetXmlGroupAvatar(XmlDocument doc) => doc.SelectSingleNode("//avatarFull").InnerText;
    public static string GetXmlGroupMemberCount(XmlDocument doc) => doc.SelectSingleNode("//memberCount").InnerText;
    public static string GetXmlGroupId(XmlDocument doc) => doc.SelectSingleNode("//groupID64").InnerText;
    public static string GetXmlGroupOwner(XmlDocument doc) => doc.SelectSingleNode("//members/steamID64").InnerText;

    public static string GetGroupAbbrevation(XmlDocument doc) => doc.SelectSingleNode("//span[@class='grouppage_header_abbrev'").InnerText;
    public static string GetGroupCreationDate(XmlDocument doc) => doc.SelectSingleNode("//div[@class='groupstat']/div[@class='data']").InnerText;
}
