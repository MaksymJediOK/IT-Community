import React, { useState } from 'react'
import AppBar from '@mui/material/AppBar'
import Box from '@mui/material/Box'
import Toolbar from '@mui/material/Toolbar'
import Typography from '@mui/material/Typography'
import { Button, Container, Stack } from '@mui/material'

export const Header = () => {
	const [auth, setAuth] = useState(true)
	const [anchorEl, setAnchorEl] = useState(null)

	const handleChange = (event) => {
		setAuth(event.target.checked)
	}

	const handleMenu = (event) => {
		setAnchorEl(event.currentTarget)
	}

	const handleClose = () => {
		setAnchorEl(null)
	}

	return (
		<>
			<Box sx={{ flexGrow: 1 }}>
				<AppBar
					position='static'
					sx={{ background: '#ffffff', borderBottom: '1px solid #111', boxShadow: 'none' }}
				>
					<Container maxWidth='lg'>
						<Toolbar disableGutters>
							<Typography
								variant='h6'
								align='left'
								color='#111'
								component='div'
								sx={{ flexGrow: 3.5, fontWeight: 700, ml: '6px' }}
							>
								IT ROOM
							</Typography>
							<Stack
								direction='row'
								spacing={6}
								color='#111'
								sx={{ flexGrow: 2, fontStyle: 'normal', fontWeight: 600 }}
							>
								<div>Articles</div>
								<div>News</div>
								<div>Salaries</div>
								<div>Companies</div>
								<div>Vacancies</div>
							</Stack>
							<Box sx={{ textTransform: 'UpperCase' }}>
								<Button
									variant='outlined'
									size='small'
									sx={{ color: '#111', border: '1px solid #111', mr: '30px' }}
								>
									Log in
								</Button>
								<Button
									variant='outlined'
									size='small'
									sx={{ color: '#111', border: '1px solid #111' }}
								>
									Register
								</Button>
							</Box>
						</Toolbar>
					</Container>
				</AppBar>
			</Box>
		</>
	)
}
