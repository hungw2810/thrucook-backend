using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Thucook.Commons.Utils
{
  public class StringIgnoreCaseComparer : IEqualityComparer<string>
  {
    // TODO: Globalization in string comparison
    // Currently only case-insensitive, culture-sensitive
    private readonly StringComparison options = StringComparison.CurrentCultureIgnoreCase;
    public bool Equals(string x, string y)
    {
      return x.Equals(y, options);
    }

    public int GetHashCode([DisallowNull] string obj)
    {
      return string.GetHashCode(obj, options);
    }
  }
}