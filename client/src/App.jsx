import { BrowserRouter } from 'react-router-dom'
import { Provider } from 'react-redux'
import { store } from './store/store'
import { CssBaseline, ThemeProvider } from '@mui/material'
import { Index } from './pages'
import { theme } from './utils/Theme'

const App = () => {
	return (
		<>
			<BrowserRouter>
				<Provider store={store}>
					<ThemeProvider theme={theme}>
						<CssBaseline />
						<Index />
					</ThemeProvider>
				</Provider>
			</BrowserRouter>
		</>
	)
}

export default App
