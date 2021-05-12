using CC.GraduationProject.BLL;
using CC.GraduationProject.Common;
using CC.GraduationProject.EFDAL;
using CC.GraduationProject.IBLL;
using CC.GraduationProject.IDAL;
using CC.GraduationProject.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace CC.GraduationProject.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CC.GraduationProject.API", Version = "v1" });
            });
            string connection = Configuration["ConnectionStringBySQL"];
            string connection2= Configuration["ConnectionStringByMySQL"];
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(connection2);//…Ë÷√ ˝æ›ø‚
            });

            services.AddSession();
            services.AddScoped(typeof(IBaseDal<>), typeof(BaseDal<>));

            services.AddScoped<IstudentBll, studentBll>();
            services.AddScoped<IteacherBll, teacherBll>();
            services.AddScoped<Istudent__curriculumBll, student__curriculumBll>();
            services.AddScoped<IcurriculumBll, curriculumBll>();
            services.AddScoped<IworkBll, workBll>();
            services.AddScoped<Istudent__workBll, student__workBll>();
            services.AddScoped<IdiscussBll, discussBll>();
            services.AddScoped<IcommentBll, commentBll>();
            services.AddScoped<IversionBll, versionBll>();
            services.AddScoped<Iquestion_choiceBll, question_choiceBll>();
            services.AddScoped<Iquestion_judgmentBll, question_judgmentBll>();
            services.AddScoped<Iquestion_fillBll, question_fillBll>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(typeof(VerificationCodeAESHelp));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddCors(options => options.AddPolicy("CorsPolicy",
               builder =>
               {
                   builder.AllowAnyMethod()
                       .SetIsOriginAllowed(_ => true)
                       .AllowAnyHeader()
                       .AllowCredentials();
               }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CC.GraduationProject.API v1"));
            }
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
