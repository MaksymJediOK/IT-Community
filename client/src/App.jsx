import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import { store } from './store/store';
import { CssBaseline } from '@mui/material';
import { Index } from './pages';

const App = () => {
	return (
		<>
			<BrowserRouter>
				<Provider store={store}>
					<CssBaseline />
					<Index />
				</Provider>
			</BrowserRouter>
		</>
	);
};

export default App;
