import React from 'react'
import styles from './ItemCard.module.scss'
import FavoriteBorderOutlinedIcon from '@mui/icons-material/FavoriteBorderOutlined'
import ChatBubbleOutlineOutlinedIcon from '@mui/icons-material/ChatBubbleOutlineOutlined'
import VisibilityOutlinedIcon from '@mui/icons-material/VisibilityOutlined'
import BookmarkAddOutlinedIcon from '@mui/icons-material/BookmarkAddOutlined'
import InsertLinkOutlinedIcon from '@mui/icons-material/InsertLinkOutlined'
import MoreHorizOutlinedIcon from '@mui/icons-material/MoreHorizOutlined'
import { CorrectDate } from 'utils/CorrectDate';

export const ItemCard = (props) => {
	const { title, views, date, thumbnail, userName, likes, comments } = props
	const validDate = CorrectDate(date)

	return (
		<>
			<h5 className={styles.date}>{validDate}</h5>
			<h2 className={styles.title}>{title}</h2>
			<div className={styles.subtitle}>What they are, their role, and further considerations</div>
			<div className={styles.content_box}>
				<img className={styles.picture} src={thumbnail} alt={title} />
			</div>
			<div className={styles.content_box}>article content</div>
			<div className={styles.tag_container}>
				{/*render tags in future*/}
				<div className={styles.tag}>
					<div className={styles.tag_text}>Design</div>
				</div>
				<div className={styles.tag}>
					<div className={styles.tag_text}>Design</div>
				</div>
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
			<div className={styles.between_container}>
				<div className={styles.flex_container}>
					<div className={styles.stats_item}>
						<FavoriteBorderOutlinedIcon />
						<div className={styles.stats_item_text}>{likes}</div>
					</div>
					<div className={styles.stats_item}>
						<ChatBubbleOutlineOutlinedIcon />
						<div className={styles.stats_item_text}>{comments}</div>
					</div>
					<div className={styles.stats_item}>
						<VisibilityOutlinedIcon />
						<div className={styles.stats_item_text}>{views}</div>
					</div>
				</div>
				<div className={styles.share_container}>
					<BookmarkAddOutlinedIcon />
					<InsertLinkOutlinedIcon />
					<MoreHorizOutlinedIcon />
				</div>
			</div>
		</>
	)
}
