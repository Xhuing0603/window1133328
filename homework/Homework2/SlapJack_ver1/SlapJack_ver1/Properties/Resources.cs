using System;
using System.Drawing;
using System.Resources;
using System.Globalization;

namespace SlapJack_ver1.Properties
{
    // Minimal Resources compatibility shim so code referencing Properties.Resources compiles
    // This uses the runtime ResourceManager to load resources from the assembly's .resx file
    internal static class Resources
    {
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        public static ResourceManager ResourceManager
        {
            get
            {
                if (resourceMan == null)
                {
                    resourceMan = new ResourceManager("SlapJack_ver1.Properties.Resources", typeof(Resources).Assembly);
                }
                return resourceMan;
            }
        }

        public static CultureInfo Culture
        {
            get => resourceCulture;
            set => resourceCulture = value;
        }

        // Provide a helper for an image named "back" commonly expected by the code.
        // If your .resx does not contain this entry, this property will return null at runtime.
        public static Image back
        {
            get
            {
                try
                {
                    object obj = ResourceManager.GetObject("back", resourceCulture);
                    return obj as Image;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
