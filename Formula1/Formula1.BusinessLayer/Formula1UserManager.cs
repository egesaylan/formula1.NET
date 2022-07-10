
using Formula1.BusinessLayer.Results;
using Formula1.DataAccessLayer.EntityFramework;
using Formula1.Entities;
using Formula1.Entities.Messages;
using Formula1.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.BusinessLayer
{
    public class Formula1UserManager 
    {
        private Repository<Formula1User> repo_user = new Repository<Formula1User>();
        public BusinessLayerResult<Formula1User> RegisterUser(RegisterViewMDL data)
        {
           Formula1User user = repo_user.Find(x => x.Username == data.Username || x.Email == data.Email);
           BusinessLayerResult<Formula1User> res = new BusinessLayerResult<Formula1User>();

            if (user != null)
            {
                if(user.Username == data.Username)
                {
                    res.AddError(ErrorMessage.UsernameAlreadyExist, "Username has been taken");
                }

                if(user.Email == data.Email)
                {
                    res.AddError(ErrorMessage.EmailAlreadyExist, "That E-Mail has already been taken");
                }  
            }
            else
            {
                int dbResult = repo_user.Insert(new Formula1User()
                {
                    Username = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = false,
                    IsAdmin = false
                    
                }); ;

                if(dbResult > 0)
                {
                    res.Result = repo_user.Find(x => x.Email == data.Email && x.Username == data.Username);
                }
            }

            return res;
        }

        public BusinessLayerResult<Formula1User> GetUserById(int ıd)
        {
            BusinessLayerResult<Formula1User> res = new BusinessLayerResult<Formula1User>();
            res.Result = repo_user.Find(x => x.Id == ıd);

            if(res.Result == null)
            {
                res.AddError(ErrorMessage.UserNotFound, "User Couldn't Find");
            }
            return res;
        }

        public BusinessLayerResult<Formula1User> LoginUser(LoginViewMdl data)
        {
            BusinessLayerResult<Formula1User> res = new BusinessLayerResult<Formula1User>();
            res.Result = repo_user.Find(x => x.Username == data.Username && x.Password == data.Password);
            
            

            if (res.Result != null)
            {
                if (!res.Result.IsActive)
                {
                    res.AddError(ErrorMessage.UserIsNotActive,"User has not been activated");
                    res.AddError(ErrorMessage.CheckYourEmail,"Please check your E-Mail for activation code");
                }
                
            }
            else
            {
                res.AddError(ErrorMessage.UsernameOrPasswordWrong,"Username or password does not match");
            }
            return res;
        }

        public BusinessLayerResult<Formula1User> UpdateProfile(Formula1User model)
        {
            Formula1User db_user = repo_user.Find(x => x.Username == model.Username || x.Email == model.Email);
            BusinessLayerResult<Formula1User> res = new BusinessLayerResult<Formula1User>();

            if(db_user != null && db_user.Id != model.Id)
            {
                if(db_user.Username == model.Username)
                {
                    res.AddError(ErrorMessage.UsernameAlreadyExist, "Username has already been taken");
                }
                if (db_user.Email == model.Email)
                {
                    res.AddError(ErrorMessage.EmailAlreadyExist, "E-Mail has already been registered");
                }
                return res;

            }
            res.Result = repo_user.Find(x => x.Id == model.Id);
            res.Result.Email = model.Email;
            res.Result.Name = model.Name;
            res.Result.Surname = model.Surname;
            res.Result.Password = model.Password;
            res.Result.Username = model.Username;

            if(string.IsNullOrEmpty(model.PP) == false)
            {
                res.Result.PP = model.PP;
            }

            if (repo_user.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessage.ProfileCouldNotUpdated, "Profile couldn't updated.");
            }
            return res;
        }

        public BusinessLayerResult<Formula1User> RemoveUserById(int ıd)
        {
            BusinessLayerResult<Formula1User> res = new BusinessLayerResult<Formula1User>();
            Formula1User user = repo_user.Find(x => x.Id == ıd);

            if(user != null)
            {
                if(repo_user.Delete(user) == 0)
                {
                    res.AddError(ErrorMessage.UserCouldNotRemove, "User Could not removed");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessage.UserCouldNotFind, "User Could Not Find");
            }
            return res;
        }
    }
}
