export const adalOptions: adal.Config = {
    tenant: '<tenant>.onmicrosoft.com',
    clientId: '<client-id>',
    redirectUri: window.location.origin,
    cacheLocation: 'localStorage',
    endpoints: {
      '/api': '<client-id>',
    },
    extraQueryParameter: "domain_hint=<domain>.com",
};
