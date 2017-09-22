using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.UnityTestTools.Assertions.Editor
{
    public class GroupByComparerRenderer : AssertionListRenderer<Type>
    {
        protected override IEnumerable<IGrouping<Type, AssertionComponent>> GroupResult(IEnumerable<AssertionComponent> assertionComponents)
        {
            return assertionComponents.GroupBy(c => c.Action.GetType());
        }

        protected override string GetStringKey(Type key)
        {
            return key.Name;
        }
    }
}
