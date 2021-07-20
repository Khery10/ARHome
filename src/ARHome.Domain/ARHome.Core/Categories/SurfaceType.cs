using System.Collections.Generic;
using ARHome.Primitives;

namespace ARHome.Core.Categories
{
    public sealed class SurfaceType : ValueObject<SurfaceType>
    {
        public SurfaceType(SurfaceTypeCode code)
            => Code = code;

        public SurfaceTypeCode Code { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}