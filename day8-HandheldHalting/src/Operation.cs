using System;

namespace HandheldHalting
{
    public record Operation(OperationType Type, int Value)
    {
        public Operation(string input) : this(Enum.Parse<OperationType>(input.Substring(0, 3)), int.Parse(input.Substring(4)))
        { }
    }
    
    public enum OperationType
    {
        acc,
        jmp,
        nop
    }   
}
