using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Mappings.AutoMapper;
using Business.ValidationRules;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contexts;
using DataAccess.UnitOfWork;
using Entities.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers.Microsoft
{
    public static class DependencyInjection
    {
        public static void IncludeInjections(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TodoApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);
            services.AddScoped(typeof(IUoW<>),typeof
                (UoW<>));
            services.AddScoped<IWorkDal, WorkDal>();
            services.AddScoped<IWorkService, WorkManager>();
            services.AddTransient<IValidator<CreateWorkDto>, CreateWorkDtoValidator>();
            services.AddTransient<IValidator<UpdateWorkDto>, UpdateWorkDtoValidator>();



        }
    }
}
