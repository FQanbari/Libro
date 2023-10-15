using Domain.Entities.MemberAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;

public class AuthorityDto
{
    public int Id { get; set; }
    public DateTime CreateOn { get; set; }
    public TokenStatusType Status { get; set; }
}
