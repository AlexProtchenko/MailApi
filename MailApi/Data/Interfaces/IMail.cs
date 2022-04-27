using MailApi.Data.Models;

namespace MailApi.Data.Interfaces;

public interface IMail
{
    void Delete(User id);
    void Delete(Department id);

    void Add(User id);
    void Add(Department id);
}