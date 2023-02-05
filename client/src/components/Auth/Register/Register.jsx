import React, { useState } from 'react'
import styles from './Register.module.scss'
import {
	Button,
	Stack,
	Box,
	TextField,
	FormControl,
	OutlinedInput,
	InputAdornment,
	IconButton,
} from '@mui/material'
import VisibilityOff from '@mui/icons-material/VisibilityOff'
import Visibility from '@mui/icons-material/Visibility'
import { Link, useNavigate } from 'react-router-dom'
import GoogleIcon from '@mui/icons-material/Google'
import { Controller, useForm } from 'react-hook-form'
import { useRegisterMutation } from '../../../services/authApi'

//ToDo divide view from logic
export const Register = () => {
	const [showPassword, setShowPassword] = useState(false)
	const [showPasswordConfirm, setShowPasswordConfirm] = useState(false)
	const navigate = useNavigate()
	const {
		formState: { errors },
		handleSubmit,
		control,
	} = useForm({
		mode: 'onBlur',
	})
	const handleClickShowPassword = () => setShowPassword((show) => !show)
	const handleClickShowPasswordConfirm = () => setShowPasswordConfirm((prevState) => !prevState)

	const [register, { isError }] = useRegisterMutation()

	const handleOnSubmit = async (data) => {
		try {
			await register(data).unwrap()
			navigate('/auth/login')
		} catch (e) {
			console.log(e)
		}
	}

	const handleMouseDownPassword = (event) => {
		event.preventDefault()
	}
	return (
		<div className={styles.container}>
			<div className={styles.auth_container}>
				<div className={styles.title}>Register</div>
				<Stack spacing={1} direction='row' alignItems='baseline'>
					<div className={styles.noAccount}> Already have account?</div>
					<Link className={styles.reg_link} to='/auth/login'>
						Sign In
					</Link>
				</Stack>
				<div className={styles.google}>
					<Stack spacing={1} direction='row' alignItems='center'>
						<GoogleIcon sx={{ width: '16px', height: '16px' }} />
						<div className={styles.google_text}>register with google</div>
					</Stack>
				</div>
				<Stack direction='row' spacing={4} alignItems='center' sx={{ margin: '40px 0 15px' }}>
					<div className={styles.line}></div>
					<div className={styles.or_text}>OR</div>
					<div className={styles.line}></div>
				</Stack>
				<Box component='form' onSubmit={handleSubmit(handleOnSubmit)}>
					<Stack spacing={3}>
						<Box componet='div'>
							<div className={styles.label_text}>Your name</div>
							<Controller
								control={control}
								name='userName'
								defaultValue=''
								render={({ field }) => (
									<TextField
										{...field}
										fullWidth
										variant='outlined'
										placeholder='John Doe'
									/>
								)}
							/>
						</Box>
						<Box componet='div'>
							<div className={styles.label_text}>Email</div>
							<Controller
								control={control}
								name='email'
								defaultValue=''
								render={({ field }) => (
									<TextField
										{...field}
										fullWidth
										variant='outlined'
										placeholder='email@gmail.com'
									/>
								)}
							/>
						</Box>
						<Box componet='div'>
							<div className={styles.label_text}>Password</div>
							<Controller
								control={control}
								name='password'
								defaultValue=''
								render={({ field }) => (
									<FormControl fullWidth variant='outlined'>
										<OutlinedInput
											{...field}
											id='outlined-adornment-password'
											placeholder='******'
											type={showPassword ? 'text' : 'password'}
											endAdornment={
												<InputAdornment position='end'>
													<IconButton
														aria-label='toggle password visibility'
														onClick={handleClickShowPassword}
														onMouseDown={handleMouseDownPassword}
														edge='end'
													>
														{showPassword ? (
															<VisibilityOff />
														) : (
															<Visibility />
														)}
													</IconButton>
												</InputAdornment>
											}
										/>
									</FormControl>
								)}
							/>
						</Box>
						<Box componet='div'>
							<div className={styles.label_text}>Confirm password</div>
							<Controller
								control={control}
								name='confirmPassword'
								defaultValue=''
								render={({ field }) => (
									<FormControl fullWidth variant='outlined'>
										<OutlinedInput
											{...field}
											id='outlined-adornment-password-confirm'
											placeholder='******'
											type={showPasswordConfirm ? 'text' : 'password'}
											endAdornment={
												<InputAdornment position='end'>
													<IconButton
														aria-label='toggle password visibility'
														onClick={handleClickShowPasswordConfirm}
														onMouseDown={handleMouseDownPassword}
														edge='end'
													>
														{showPasswordConfirm ? (
															<VisibilityOff />
														) : (
															<Visibility />
														)}
													</IconButton>
												</InputAdornment>
											}
										/>
									</FormControl>
								)}
							/>
						</Box>
					</Stack>

					<Button type='submit' variant='contained' size='large' fullWidth sx={{ mt: '32px' }}>
						REGISTER
					</Button>
				</Box>
			</div>
		</div>
	)
}
