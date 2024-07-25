using Product.Models.Admin;

namespace Product.Repository.Interface
{
    public interface IAct
    {
        ActDTOResponse List(string userName);
    }
}
