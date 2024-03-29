import { AuthConfig } from 'angular-oauth2-oidc'

export function createAuthConfig(callbackUrl: string): AuthConfig {
  return {
    clientId: 'bif4ss2019ue5',
    // Url of the Identity Provider
    issuer: 'https://bif4-web-identity.azurewebsites.net',
    // The SPA's id. The SPA is registered with this id at the auth-server clientId: 'bif4ss2018ue5',
    redirectUri: callbackUrl,
    postLogoutRedirectUri: callbackUrl,
    // set the scope for the permissions the client should request
    // The first three are defined by OIDC.
    scope: 'openid profile ue5-api'
  };
}
