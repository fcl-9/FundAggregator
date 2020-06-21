
export class AppConfig {
    static apiEndpoint: string;
}

export function initApp() {
    return () => {
    //   return new Promise((resolve) => {
          AppConfig.apiEndpoint = "https://localhost:5001/api";
          return Promise.resolve();
        // setTimeout(() => {
        //   console.log('In initApp');
        //   resolve();
        // }, 3000);
    //   });
    };
  }
