[3]
3.-Vad är syftet med interfacet? Syftet med interfacet är för att vi ska kunna återanvända metoden processpayment i andra klasser. 
Det görs genom arvningen av interfacet. 
-Hur registreras StoreService som service? svar: Som builder.Services.AddSingleton<StoreService>();
- Hur väljs SwishPayment som registrerad service? svar: builder.Services.AddSingleton<IpaymentProcessor, SwishPayment>();