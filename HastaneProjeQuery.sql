create proc KullaniciGiris
@Ad varchar(50),
@Sifre varchar(50)
as begin
select KullaniciAd, Sifre from Kullanicilar where KullaniciAd = @Ad and Sifre =@Sifre 
end
create proc KullaniciAdSorgulama
@Ad varchar(50)
as begin
select KullaniciAd from Kullanicilar where KullaniciAd=@Ad
end
create proc KullaniciEkle
@KullaniciAdSoyad varchar(50),
@Sifre varchar(50),
@Email varchar(50),
@TelefonNo char(20)
as begin
insert into Kullanicilar(KullaniciAd,Sifre,Email,TelefonNo)
values(@KullaniciAdSoyad,@Sifre,@Email,@TelefonNo)
end
create proc PolGuncelleme
@PolNo int,
@PolAdi varchar(50),
@PolUzmanSayisi int,
@PolBaskan varchar(50),
@PolBasHekim varchar(50),
@YatakSayisi int
as begin
update Polikinilikler set PolAdi=@PolAdi,PolUzmanSayisi=@PolUzmanSayisi,PolBaskan = @PolBaskan,PolBasHekim = @PolBasHekim,YatakSayisi=@YatakSayisi where PolNo=@PolNo
end
create proc PolSilme
@PolNo int
as begin
delete Polikinilikler where PolNo = @PolNo
end
create proc PolListeleAZ
as begin
select * from Polikinilikler order by PolAdi
end
create proc PolListeleZA
as begin
select * from Polikinilikler order by PolAdi DESC
end
create proc PolListele
as begin
select * from Polikinilikler 
end
create proc DoktorListele
as begin
select * from Doktorlar 
end
create proc DoktorListeleAZ
as begin
select * from Doktorlar order by DoktorAdSoyad 
end
create proc DoktorListeleZA
as begin
select * from Doktorlar order by DoktorAdSoyad desc
end
create proc HastaListele
as begin
select * from Hastalar 
end
create proc HastaListeleAZ
as begin
select * from Hastalar order by HastaAdSoyad 
end
create proc HastaListeleZA
as begin
select * from Hastalar order by HastaAdSoyad desc
end
create proc PolEkle
@PolAdi varchar(50),
@PolUzmanSayisi int,
@PolBaskan varchar(50),
@PolBasHekim varchar(50),
@YatakSayisi int
as begin
insert into Polikinilikler(PolAdi,PolUzmanSayisi,PolBaskan,PolBasHekim,YatakSayisi)
values(@PolAdi,@PolUzmanSayisi,@PolBaskan,@PolBasHekim,@YatakSayisi)
end
create proc HastaEkle
@HastaAdSoyad varchar(50),
@TcNo  char(11),
@DogumTarihi varchar(50),
@Boy int,
@Yas int,
@Recete varchar(50),
@RaporDurumu varchar(50),
@RandevuTarihi varchar(50),
@DoktorNo int
as begin
insert into Hastalar(HastaAdSoyad,TcNo,DogumTarihi,Boy,Yas,Recete,RaporDurumu,RandevuTarih,DoktorNo)
values(@HastaAdSoyad,@TcNo,@DogumTarihi,@Boy,@Yas,@Recete,@RaporDurumu,@RandevuTarihi,@DoktorNo)
end
create proc HastaGuncelleme
@HastaNo int,
@HastaAdSoyad varchar(50),
@TcNo  char(11),
@DogumTarihi varchar(50),
@Boy int,
@Yas int,
@Recete varchar(50),
@RaporDurumu varchar(50),
@RandevuTarihi varchar(50),
@DoktorNo int
as begin
update Hastalar set HastaAdSoyad=@HastaAdSoyad,TcNo=@TcNo,DogumTarihi=@DogumTarihi,Boy=@Boy,Yas=@Yas,Recete=@Recete,RaporDurumu=@RaporDurumu,RandevuTarih=@RandevuTarihi,DoktorNo =@DoktorNo where HastaNo =@HastaNo
end
create proc HastaSilme
@HastaNo int
as begin
delete Hastalar where HastaNo = @HastaNo
end
create proc DoktorEkle
@DoktorAdiSoyad varchar(50),
@TcNo char(11),
@UzmanlikAlani varchar(50),
@Telefon char(15),
@Adres varchar(50),
@DogumTarihi varchar(50),
@PolNo int 
as begin
insert into Doktorlar(DoktorAdSoyad,Tc,UzmanlikAlani,Telefon,Adres,DogumTarihi,PolNo)
values(@DoktorAdiSoyad,@TcNo,@UzmanlikAlani,@Telefon,@Adres,@DogumTarihi,@PolNo)
end
create proc DoktorGuncelleme
@DoktorNo int,
@DoktorAdiSoyad varchar(50),
@TcNo char(11),
@UzmanlikAlani varchar(50),
@Unvan varchar(50),
@Telefon char(15),
@Adres varchar(50),
@DogumTarihi varchar(50),
@PolNo int 
as begin
update Doktorlar set DoktorAdSoyad=@DoktorAdiSoyad,Tc=@TcNo,UzmanlikAlani=@UzmanlikAlani,Unvan=@Unvan,Telefon=@Telefon,Adres=@Adres,DogumTarihi=@DogumTarihi,PolNo= @PolNo where DoktorNo=@DoktorNo
end
create proc DoktorSil
@DoktorNo int
as begin 
delete Doktorlar where DoktorNo= @DoktorNo
end
create proc PolNoBul
@Pol varchar(50)
as begin
select PolNo from Polikinilikler where PolAdi = @Pol
end
create proc DoktorNoBul
@DoktorAdSoyad varchar(50)
as begin
select DoktorNo from Doktorlar where DoktorAdSoyad = @DoktorAdSoyad
end
create proc PolAdBul
@PolNo int
as begin
select PolAdi from Polikinilikler where PolNo = @PolNo
end
exec PolAdBul 2