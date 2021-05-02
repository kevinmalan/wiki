import {environment} from '../../environments/environment';

export const WikiApiRoutes = {
    register: `${environment.wikiApiUri}/auth/register`,
    signIn: `${environment.wikiApiUri}/auth/signin"`
}