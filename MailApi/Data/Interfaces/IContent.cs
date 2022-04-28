using MailApi.Data.Models;

namespace MailApi.Data.Interfaces;

public interface IContent
{
    void Delete(User id);
    void Delete(Department id);
    
    void Update(User id);
    void Update(Department id);

    void Add(User id);
    void Add(Department id);
    
}