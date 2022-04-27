using MailApi.Data.Models;

namespace MailApi.Data.Interfaces;

public interface IMail
{
    void Delete(User selectedItem);
    bool Delete(Department selectedItem);

    void Add(User contact);
    void Add(Department department);
}