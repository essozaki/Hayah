using AutoMapper;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Models;

namespace Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Client, ClientVM>();
            CreateMap<ClientVM, Client>();

     
            CreateMap<AnalysisLaps, AnalysisLapsVM>();
            CreateMap<AnalysisLapsVM, AnalysisLaps>();

     
            CreateMap<Areas, AreasVM>();
            CreateMap<AreasVM, Areas>();

     
            CreateMap<Cities, CitiesVM>();
            CreateMap<CitiesVM, Cities>();

     
            CreateMap<Client, ClientVM>();
            CreateMap<ClientVM, Client>();
     
            CreateMap<Clincs, ClincsVM>();
            CreateMap<ClincsVM, Clincs>();

     
            CreateMap<Complains, ComplainsVM>();
            CreateMap<ComplainsVM, Complains>();

            CreateMap<ContactUs, ContactUsVM>();
            CreateMap<ContactUsVM, ContactUs>();

            CreateMap<HomeSlider, HomeSliderVM>();
            CreateMap<HomeSliderVM, HomeSlider>();

            CreateMap<Hospitals, HospitalsVM>();
            CreateMap<HospitalsVM, Hospitals>();

            CreateMap<Medical_Information, Medical_InformationVM>();
            CreateMap<Medical_InformationVM, Medical_Information>();

            CreateMap<Pharmacies, PharmaciesVM>();
            CreateMap<PharmaciesVM, Pharmacies>();

            CreateMap<Questions, QuestionsVM>();
            CreateMap<QuestionsVM, Questions>();

            CreateMap<Terms_Conditions, Terms_ConditionsVM>();
            CreateMap<Terms_ConditionsVM, Terms_Conditions>();

            CreateMap<Xrays, XraysVM>();
            CreateMap<XraysVM, Xrays>();

     




        }
    }
}
