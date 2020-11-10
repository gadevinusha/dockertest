"use strict";
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
//uncommet if not azure ad
//export const environment = {
//  production: false
//};
Object.defineProperty(exports, "__esModule", { value: true });
exports.environment = void 0;
//for AZure ad
exports.environment = {
    production: false,
    baseUrl: 'https://localhost:44373/',
    scopeUri: ['api://b7f0e62c-eefa-4d38-95ed-76e0ecf9bc3a/access_as_user'],
    tenantId: '90ecffef-2c21-4cbc-bcf9-2e8685d7ac07',
    uiClienId: '2cd9757c-c535-4c2d-bf90-5feab5edc062',
    redirectUrl: 'https://localhost:44373/',
};
/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
//# sourceMappingURL=environment.js.map