module.exports = {
  purge: {
    content: [
      './**/*.html',
      './**/*.razor',
      './**/**/*.razor',
    ],
  },
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      colors: {
        background: '#F1EDE4'
      }
      
    },
  },
  variants: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/forms'),
  ],
}
