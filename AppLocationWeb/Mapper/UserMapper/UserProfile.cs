using AppLocationWeb.Models;
using AutoMapper;
using Backend.AppLocation.Entities;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>();
    }
}