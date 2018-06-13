export class TokenService {
    public buildToken(): string {
        let token: string = localStorage.getItem('token').replace("\"", "");
        if(token.length > 36)
            token = token.substring(0, token.length - 1);

        return token;
    }
}