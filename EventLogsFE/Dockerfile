# Stage 1: Build the Angular app
FROM node:20-alpine AS build
WORKDIR /app

# Copy package files and install dependencies
COPY package*.json ./
RUN npm install

# Copy the rest of the code and build for production
COPY . .
RUN npm run build -- --configuration=production

# Stage 2: Serve the app with Nginx
FROM nginx:stable-alpine
# Copy the build output to Nginx's html folder
# Replace 'EventLogsFE' with your actual project name from angular.json
COPY --from=build /app/dist/EventLogsFE/browser /usr/share/nginx/html

# Expose port 80
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]