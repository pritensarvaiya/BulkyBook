# Stage 1
FROM node:14.15.5 as build
WORKDIR /usr/local/app
COPY ./ /usr/local/app
RUN npm install
RUN npm run build
# Stage 2
FROM nginx:alpine
COPY --from=build /usr/local/app/dist/bulky-book.ui/ /usr/share/nginx/html
EXPOSE 80
