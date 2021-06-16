using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public Skill GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetList()
        {
            return _skillDal.List(); 
        }

        public void SkillAdd(Skill skill)
        {
            throw new NotImplementedException();
        }

        public void SkillDelete(Skill skill)
        {
            throw new NotImplementedException();
        }

        public void SkillUpdate(Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}
