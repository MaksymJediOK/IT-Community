import React from 'react'
import styles from './Account.module.scss'
import { Stack, TextField, Box, Button } from '@mui/material'

export const Account = () => {
	return (
		<div className={styles.inner_container}>
			<Stack sx={{ mb: '64px' }}>
				<div className={styles.text}>Change username</div>
				<Stack direction='row' alignItems='center'>
					<div className={styles.address}>itroom.com / </div>
					<TextField
						variant='outlined'
						size='small'
						label='Username'
						sx={{ ml: '15px', width: '250px' }}
					/>
					<Box sx={{ width: '245px' }}>
						<div className={styles.helper_text}>
							The username is your personal address and they way you can be found across
							the community
						</div>
					</Box>
				</Stack>
			</Stack>
			<Stack sx={{ mb: '64px' }}>
				<div className={styles.text}>Change email</div>
				<Stack direction='row' alignItems='center'>
					<TextField
						variant='outlined'
						size='small'
						sx={{ width: '368px' }}
						placeholder='Email here'
					/>
					<Box sx={{ width: '245px' }}>
						<div className={styles.helper_text}>
							The username is your personal address and they way you can be found across
							the community
						</div>
					</Box>
				</Stack>
			</Stack>
			<Stack sx={{ mb: '18px' }}>
				<div className={styles.text}>Current password</div>
				<Stack direction='row' alignItems='center'>
					<TextField
						variant='outlined'
						size='small'
						sx={{ width: '368px' }}
						type='password'
						placeholder='*****'
					/>
					<Box sx={{ width: '245px' }}>
						<div className={styles.helper_text}>
							The username is your personal address and they way you can be found across
							the community
						</div>
					</Box>
				</Stack>
			</Stack>
			<Stack>
				<div className={styles.text}>New password</div>
				<Stack direction='row' alignItems='center'>
					<TextField
						variant='outlined'
						size='small'
						sx={{ width: '368px' }}
						type='password'
						placeholder='*****'
					/>
				</Stack>
			</Stack>
			<Stack direction='row' sx={{ mt: '64px' }}>
				<Button variant='contained' sx={{ width: '148px' }}>
					SAVE CHANGES
				</Button>
				<Button variant='outlined' sx={{ width: '102px', ml: '94px' }}>
					DISCARD
				</Button>
			</Stack>
		</div>
	)
}
