using System.Reflection;
using MSAYearBook.Data;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace MSAYearBook.Extensions
{
    public class UseAppDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<AppDbContext>();
        }
    }
}
