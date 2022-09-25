namespace AdventOfCode.Year2021.Day16;

public static class Solver
{
    public static object GetSumOfAllVersions(string input)
    {
        var hexadecimal = input;
        var packet = new Packet(ConvertToBinary(hexadecimal));

        return packet.PacketVersionSum;
    }

    private static string ConvertToBinary(string hexadecimal)
    {
        return string.Join(string.Empty, hexadecimal.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
    }

    public static long CalculateTransmissonExpression(string input)
    {
        var hexadecimal = input;
        var packet = new Packet(ConvertToBinary(hexadecimal));

        return packet.Value;
    }
}