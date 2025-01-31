
namespace System
{
    public class Object
    {
        // The layout of object is a contract with the compiler.
        public IntPtr m_pEEType;
    }
    public struct Void { }

    // The layout of primitive types is special cased because it would be recursive.
    // These really don't need any fields to work.
    public struct Boolean { }
    public struct Char { }
    public struct SByte { }
    public struct Byte { }
    public struct Int16 { }
    public struct UInt16 { }
    public struct Int32 { }
    public struct UInt32 { }
    public struct Int64 { }
    public struct UInt64 { }
    public struct UIntPtr { }
    public struct Single { }
    public struct Double { }

    public unsafe struct IntPtr
    {
        private void* _value;
        public IntPtr(void* value) { _value = value; }
    }

    public abstract class ValueType { }
    public abstract class Enum : ValueType { }

    public struct Nullable<T> where T : struct { }
    
    public sealed class String
    {
        // The layout of the string type is a contract with the compiler.
        public readonly int Length;
        public char _firstChar;

        public unsafe char this[int index]
        {
            [System.Runtime.CompilerServices.Intrinsic]
            get
            {
                return Internal.Runtime.CompilerServices.Unsafe.Add(ref _firstChar, index);
            }
        }
    }
    public abstract class Array { }
    public abstract class Delegate { }
    public abstract class MulticastDelegate : Delegate { }

    public struct RuntimeTypeHandle { }
    public struct RuntimeMethodHandle { }
    public struct RuntimeFieldHandle { }

    public class Attribute { }
}

namespace System.Runtime.CompilerServices
{
    internal sealed class IntrinsicAttribute : Attribute { }

    public class RuntimeHelpers
    {
        public static unsafe int OffsetToStringData => sizeof(IntPtr) + sizeof(int);
    }

    public enum MethodImplOptions
    {
        NoInlining = 0x0008,
    }

    public sealed class MethodImplAttribute : Attribute
    {
        public MethodImplAttribute(MethodImplOptions methodImplOptions) { }
    }
}

namespace System.Runtime.InteropServices
{
    public enum CharSet
    {
        None = 1,
        Ansi = 2,
        Unicode = 3,
        Auto = 4,
    }

    public sealed class DllImportAttribute : Attribute
    {
        public string EntryPoint;
        public CharSet CharSet;
        public DllImportAttribute(string dllName) { }
    }

    public enum LayoutKind
    {
        Sequential = 0,
        Explicit = 2,
        Auto = 3,
    }

    public sealed class StructLayoutAttribute : Attribute
    {
        public StructLayoutAttribute(LayoutKind layoutKind) { }
    }
}
namespace Internal.Runtime.CompilerServices
{
    public static unsafe partial class Unsafe
    {
        // The body of this method is generated by the compiler.
        // It will do what Unsafe.Add is expected to do. It's just not possible to express it in C#.
        [System.Runtime.CompilerServices.Intrinsic]
        public static extern ref T Add<T>(ref T source, int elementOffset);
    }
}
