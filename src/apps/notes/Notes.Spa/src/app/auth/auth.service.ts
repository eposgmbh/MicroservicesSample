import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { filter } from 'rxjs/operators';

import * as auth0 from 'auth0-js';

import { environment } from '../../environments/environment'

@Injectable()
export class AuthService {

    auth0 = new auth0.WebAuth({
        clientID: '3mjlpP6oSunKYHCdRwa6MHTFJrYsyPv7',
        domain: 'notes-spa.eu.auth0.com',
        responseType: 'token id_token',
        audience: 'https://notes-spa.eu.auth0.com/userinfo',
        redirectUri: environment.auth0RedirectUri,
        scope: 'openid profile email'
    });

    constructor(public router: Router) { }

    public login() {
        this.auth0.authorize();
    }

    public handleAuthentication() {
        this.auth0.parseHash((err, authResult) => {
            if (authResult && authResult.accessToken && authResult.idToken) {
                window.location.hash = '';
                this.setSession(authResult);
                console.log(authResult);
                this.router.navigate(['/']);
            } else if (err) {
                this.router.navigate(['/']);
                console.log(err);
            }
        });
    }

    private setSession(authResult): void {
        const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());

        localStorage.setItem('access_token', authResult.accessToken);
        localStorage.setItem('id_token', authResult.idToken);
        localStorage.setItem('expires_at', expiresAt);
    }

    public logout(): void {
        localStorage.removeItem('access_token');
        localStorage.removeItem('id_token');
        localStorage.removeItem('expires_at');

        this.router.navigate(['/']);
    }

    public isAuthenticated(): boolean {
        const expiresAt = JSON.parse(localStorage.getItem('expires_at'));
        return new Date().getTime() < expiresAt;
    }
}
