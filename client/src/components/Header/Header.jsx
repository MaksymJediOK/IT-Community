import React from 'react'
import styles from './Header.module.scss'
import AppBar from '@mui/material/AppBar'
import Box from '@mui/material/Box'
import Toolbar from '@mui/material/Toolbar'
import Typography from '@mui/material/Typography'
import { Button, Container, Stack } from '@mui/material'
import { UserBar } from '../UserBar/UserBar'
import { useIsAuthorized } from '../../hooks/useIsAuthorized'
import { Link } from 'react-router-dom'
import { UserPopover } from '../../features/Popover'

export const Header = () => {
	const answer = useIsAuthorized()

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
								sx={{ flexGrow: 3.5, fontWeight: 700, ml: '10px' }}
							>
								IT ROOM
							</Typography>
							<Stack direction='row' spacing={6} sx={{ flexGrow: 2 }}>
								<Link className={styles.link} to='/articles'>
									Articles
								</Link>
								<Link className={styles.link} to='/'>
									News
								</Link>
								<Link className={styles.link} to='/'>
									Salaries
								</Link>
								<Link className={styles.link} to='/'>
									Companies
								</Link>
								<Link className={styles.link} to='/vacancies'>
									Vacancies
								</Link>
							</Stack>
							<Box sx={{ textTransform: 'UpperCase' }}>
								{answer ? (
									<>
										<UserBar />
										<UserPopover />
									</>
								) : (
									<>
										<Button variant='outlined' size='small' sx={{ mr: '30px' }}>
											<Link to='/auth/login' style={{ all: 'unset' }}>
												Log in
											</Link>
										</Button>
										<Button variant='outlined' size='small'>
											<Link to='/auth/register' style={{ all: 'unset' }}>
												Register
											</Link>
										</Button>
									</>
								)}
							</Box>
						</Toolbar>
					</Container>
				</AppBar>
			</Box>
		</>
	)
}
