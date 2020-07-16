const ENV = {
  dev: {
    apiUrl: 'http://localhost:44399',
    oAuthConfig: {
      issuer: 'http://localhost:44399',
      clientId: 'SignalRTieredDemo_App',
      clientSecret: '1q2w3e*',
      scope: 'SignalRTieredDemo',
    },
    localization: {
      defaultResourceName: 'SignalRTieredDemo',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44399',
    oAuthConfig: {
      issuer: 'http://localhost:44399',
      clientId: 'SignalRTieredDemo_App',
      clientSecret: '1q2w3e*',
      scope: 'SignalRTieredDemo',
    },
    localization: {
      defaultResourceName: 'SignalRTieredDemo',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
