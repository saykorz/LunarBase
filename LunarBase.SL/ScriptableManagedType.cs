using System.Windows.Browser;

namespace LunarBase.SL
{
    public class ScriptableManagedType
    {
        [ScriptableMember()]
        public string MyToUpper(string str)
        {
            return str.ToUpper();
        }

        [ScriptableMember()]
        public string Name { get; set; }
    }
}
