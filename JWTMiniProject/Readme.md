# JWT Mini Project – ASP.NET Core 8.0

## Açýklama

Bu proje, **manuel kullanýcý yönetimi** ile JWT (JSON Web Token) üreten bir ASP.NET Core 8.0 uygulamasýdýr.  
Kullanýcýlar sisteme giriþ yaptýktan sonra **Token Oluþtur** butonuna basarak JWT alabilirler.

- Kullanýcý iþlemleri(Login,Register) manuel olarak yapýlmýþtýr.
- Token oluþturma ve gösterme **TokenController** üzerinden yapýlýr.  
- Kullanýcý login deðilse, Token sayfasýna eriþim engellenir.
- Kullanýcý login olduðunda token üretilir.

---

## Özellikler

- Kullanýcý Register ve Login iþlemleri  
- JWT token üretme  
- Üretilen token’ý web sayfasýnda gösterme  
- Login olmayan kullanýcýlarý AccessDenied hatasý yönlendirme
- Program.cs deki Registiration kodlarýný ilgili katmanlarda yazma

---

## Teknolojiler

- ASP.NET Core 8.0  
- Entity Framework Core  
- AutoMapper  
- JWT Authentication  

---

## Kurulum

1. Repository’i klonlayýn:

```bash
git clone https://github.com/sehercelikk/JWTMiniProject.git
cd JWTMiniProject

2.Secret.json veya appsettings.json dosyasýnda JWT ve Veritabaný bilgilerini doldurun:

```bash
{
  "Jwt": {
    "Key": "BuKendiUrettiðinizGizliKey",
    "Issuer": "JwtProject",
    "Audience": "JwtProject"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=JwtProjectDb;Trusted_Connection=True;"
  }
}

3. Database’i oluþtur ve migration’larý uygula:
```bash
PMC: Add-Migration InitialCreate
PMC: Update-Database

```

### Login Sayfasý
![Login Sayfasý](JWTMiniProject/ProjectImages/jwt0.PNG)

### Register Sayfasý
![Login Sayfasý](JWTMiniProject/ProjectImages/jwt3.PNG)

### Token Sayfasý
![Login Sayfasý](JWTMiniProject/ProjectImages/jwt1.PNG)
![Login Sayfasý](JWTMiniProject/ProjectImages/jwt2.PNG)



