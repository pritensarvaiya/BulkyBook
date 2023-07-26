# Stage 1: Build the Angular app
FROM node:14.15.5 as build
WORKDIR /usr/local/app
COPY ./BulkyBookUI/package.json ./BulkyBookUI/package-lock.json ./
RUN npm install
COPY ./BulkyBookUI .
RUN npm run build

# Stage 2: Create the production image
FROM nginx:alpine
COPY --from=build /usr/local/app/dist/bulky-book.ui/ /usr/share/nginx/html
EXPOSE 80
