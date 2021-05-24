using System.Threading.Tasks;
using Ordering.Application.Models;
using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}