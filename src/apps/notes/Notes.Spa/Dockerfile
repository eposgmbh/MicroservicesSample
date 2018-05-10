FROM node:8.10-alpine as build-env

WORKDIR /build

COPY package.json ./
RUN npm install

COPY ./ ./
RUN npm run build -- --prod

# ---------------------------------------

FROM nginx:1.13

COPY --from=build-env /build/dist /usr/share/nginx/html
COPY ./nginx-custom.conf /etc/nginx/conf.d/default.conf

ADD https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh ./
RUN chmod +x wait-for-it.sh

EXPOSE 80

ENTRYPOINT ["nginx", "-g", "daemon off;"]
