
using Persons_App.Domain.Enums;

namespace Persons_App.Domain.Entities
{
    public class RelatedPerson
    {
        public int  Id { get; set; }
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public  RelationType RelationType{ get; set; }
        public Person Person { get; set; }

    }
}