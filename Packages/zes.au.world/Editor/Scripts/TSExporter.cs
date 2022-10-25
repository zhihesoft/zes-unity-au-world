using Puerts;
using System;
using System.Collections.Generic;

namespace Au.World
{
    [Configure]
    public class TSExporter
    {
        [Binding]
        public static IEnumerable<Type> bindings
        {
            get
            {
                return new[] {
                typeof(Au.AssetSet),
                typeof(Au.Async),
                typeof(Au.Files),
                typeof(Au.I18n),
                typeof(Au.Tags),
                typeof(Au.Fader),

                typeof(Au.TS.TSApp),
            };
            }
        }
    }
}

