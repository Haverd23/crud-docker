FROM node:20 AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . ./
RUN npm run build --prod
FROM nginx:alpine AS runtime
COPY --from=build /app/dist/teste/browser  /usr/share/nginx/html
EXPOSE 80
