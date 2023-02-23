import React from 'react'
import styles from './ArticlePreview.module.scss'
import { Grid } from '@mui/material'
import FavoriteIcon from '@mui/icons-material/Favorite'
import VisibilityIcon from '@mui/icons-material/Visibility'
import ChatBubbleIcon from '@mui/icons-material/ChatBubble'
import { CorrectDate } from 'utils/CorrectDate'
import { Link } from 'react-router-dom'
import { IconLabel } from '../UI/IconsActions/IconLabel'

export const ArticlePreview = (props) => {
	const {
		isLabel = false,
		Icon = null,
		id,
		title,
		views,
		date,
		thumbnail,
		userName,
		likes,
		comments,
	} = props
	const validDate = CorrectDate(date)
	return (
		<Grid item xs={6}>
			<div className={styles.container}>
				<div className={styles.position_container}>
					<img className={styles.img_container} src={thumbnail} alt='Thumbnail' />
					{isLabel ? <IconLabel>{Icon}</IconLabel> : ''}
				</div>
				<div className={styles.inner_container}>
					<div className={styles.author_section}>
						<div className={styles.author_section_text}>{userName}</div>
						<div className={styles.author_section_text}>{validDate}</div>
					</div>
					<Link to={`/articles/${id}`} className={styles.title}>
						{title}
					</Link>
					<div className={styles.tags_container}>
						<div className={styles.tag}>
							<div className={styles.tag_text}>Design</div>
						</div>
						<div className={styles.tag}>
							<div className={styles.tag_text}>Design</div>
						</div>
						<div className={styles.tag}>
							<div className={styles.tag_text}>Design</div>
						</div>
					</div>
					<div className={styles.reactions_container}>
						<div className={styles.reaction_block}>
							<FavoriteIcon sx={{ width: '12px', height: '12px' }} />{' '}
							<span className={styles.reaction_block_number}>{likes}</span>
						</div>
						<div className={styles.reaction_block}>
							<VisibilityIcon sx={{ width: '12px', height: '12px' }} />{' '}
							<span className={styles.reaction_block_number}>{views}</span>
						</div>
						<div className={styles.reaction_block}>
							<ChatBubbleIcon sx={{ width: '12px', height: '12px' }} />{' '}
							<span className={styles.reaction_block_number}>{comments}</span>
						</div>
					</div>
				</div>
			</div>
		</Grid>
	)
}
